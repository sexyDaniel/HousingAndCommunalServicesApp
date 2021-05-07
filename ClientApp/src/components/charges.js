import React from 'react';

export default class Charges extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            start: this.props.values.startChargeDate,
            finish: this.props.values.finishChargeDate,
            data: JSON.parse(localStorage.getItem('owner')),
            charges:[]
        }
        this.filterChargePost = this.filterChargePost.bind(this)
        this.onChangeStartDate = this.onChangeStartDate.bind(this)
        this.onChangeFinishDate = this.onChangeFinishDate.bind(this)
    }
    onChangeFinishDate(e) {
        this.setState({ finish: e.target.value })
        this.props.values.finishChargeDate = e.target.value
    }
    onChangeStartDate(e) {
        this.setState({ start: e.target.value })
        this.props.values.startChargeDate = e.target.value
    }
    async componentDidMount() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                StartDate: this.state.start,
                EndDate: this.state.finish
            })
        };
        const response = await fetch('/Charge/GetChargesByDate', requestOptions);
        const data = await response.json();
        this.setState({ charges: data })
    }
    async filterChargePost(e) {
        e.preventDefault();
        if (!this.state.start || !this.state.finish) {
            alert("Введите обе даты")
        } else if (new Date(this.state.start) > new Date(this.state.finish)) {
            alert("Дата С должна быть меньше даты ПО")
        } else {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    StartDate: this.state.start,
                    EndDate: this.state.finish
                })
            };
            const response = await fetch('/Charge/GetChargesByDate', requestOptions);
            const data = await response.json();
            this.setState({ charges: data })
        }
    }   
    render() {
        console.log(this.state.data)
        return <div>
            <h1>Начисления</h1>
            <div className="owner-info">
                <h4>Собственник:{this.state.data.owner.lastName} {this.state.data.owner.firstName} {this.state.data.owner.patronymic}</h4>
            </div>
            <div className="row charge-tabs">
                <div className="col-9 charge-tables">
                    {
                        this.state.charges.map(function (c) {
                            return <div className="charge-info shadow charge-table">
                                <div className="service-company">
                                    <h5>Адрес: г. {c.charge.property.building.city.name} {c.charge.property.building.street} {c.charge.property.building.buildingNumber} кв. {c.charge.property.apartmentNumber}</h5>
                                </div>
                                <div className="charge">
                                    <h6>Дата начисления: {c.charge.chargeDate.substring(0, 10) }</h6>
                                    <table className="table table-primary">
                                        <thead>
                                            <tr>
                                                <th>Вид платежа</th>
                                                <th>Кол-во ед. изм.</th>
                                                <th>Размер платы (руб/ед изм.)</th>
                                                <th>Начисленно фактически</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>{c.charge.service.name}</td>
                                                <td>{c.charge.volume}</td>
                                                <td>{c.tariff.value}</td>
                                                <td>{c.tariff.value * c.charge.volume} руб</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        })
                    }
                   
                </div>
                <div className="col-3">
                    <h3>Фильтр</h3>
                    <form onSubmit={this.filterChargePost} className="charge-form">
                        <span>С:</span><input type="date" onChange={this.onChangeStartDate} defaultValue={this.state.start} className="form-control" />
                        <span>По:</span><input type="date" onChange={this.onChangeFinishDate} defaultValue={this.state.finish} className="form-control" />
                        <button className="btn btn-primary">Вывести все начисления</button>
                    </form>
                </div>
            </div>
        </div>;
    }
}