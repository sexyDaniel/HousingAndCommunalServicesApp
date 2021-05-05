import React from 'react';

export default class Charges extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            start: "",
            finish:'',
            data: JSON.parse(localStorage.getItem('owner')),
            charges:[]
        }
    }
    async componentDidMount() {
        var toDay = new Date()
        var daysCount = 32 - new Date(toDay.getFullYear(), toDay.getMonth(), 32).getDate();
        var month = toDay.getMonth() + 1
        var start = toDay.getFullYear() + '-' + 0+month + '-' +'01'
        var finish = toDay.getFullYear() + '-' + 0 + month + '-' + daysCount
        this.setState({ start: start })
        this.setState({ finish: finish })
        console.log(start)
        console.log(finish)
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                StartDate: start,
                EndDate: finish,
            })
        };
        const response = await fetch('/Charge/GetChargesByDate', requestOptions);
        const data = await response.json();
        this.setState({ charges: data })
        console.log(data)
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
                                    <h5>Название: ООО "Обслуживающая компания"</h5>
                                    <h5>Телефон: 88005553535</h5>
                                </div>
                                <div className="charge">
                                    <h6>Дата начисления:{c.chargeDate }</h6>
                                    <table className="table table-primary">
                                        <thead>
                                            <tr>
                                                <th>Вид платежа</th>
                                                <th>Единицы измерения</th>
                                                <th>Кол-во ед. изм.</th>
                                                <th>Размер платы (руб/ед изм.)</th>
                                                <th>Начисленно фактически</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Обращение с ТКО</td>
                                                <td>куб. м</td>
                                                <td>444</td>
                                                <td>567</td>
                                                <td>4900</td>
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
                    <form className="charge-form">
                        <span>С:</span><input type="date" defaultValue={this.state.start} className="form-control" />
                        <span>По:</span><input type="date" defaultValue={this.state.finish} className="form-control" />
                        <button className="btn btn-primary">Вывести все начисления</button>
                    </form>
                </div>
            </div>
        </div>;
    }
}