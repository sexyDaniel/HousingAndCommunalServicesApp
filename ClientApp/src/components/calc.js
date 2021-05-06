import React from 'react';
import Cookies from 'js-cookie';

export default class Calc extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            tariff: this.props.values.tariff,
            volume: this.props.values.volume,
            res: this.props.values.res,
            monthCalc: this.props.values.monthCalc,
            resCalcMonth: this.props.values.resCalcMonth,
            yearCalc: this.props.values.yearCalc,
            resCalcYear: this.props.values.resCalcYear,
            startDate: this.props.values.startDate,
            finishDate: this.props.values.finishDate,
            resPeriod: this.props.values.resPeriod,
            tariffs:[]
        }

        this.press = this.press.bind(this);
        this.onTariffChange = this.onTariffChange.bind(this)
        this.onVolumeChange = this.onVolumeChange.bind(this)
        this.onMonthCalcChange = this.onMonthCalcChange.bind(this)
        this.onYearhCalcChange = this.onYearhCalcChange.bind(this)
        this.onStartDateChange = this.onStartDateChange.bind(this)
        this.onFinishDateChange = this.onFinishDateChange.bind(this)
        this.calcMonth = this.calcMonth.bind(this)
        this.calcYear = this.calcYear.bind(this)
        this.calcPeriod = this.calcPeriod.bind(this)
        this.componentDidMount = this.componentDidMount.bind(this)
    }
    async calcPeriod(e) {
        e.preventDefault();
        if (!this.state.startDate || !this.state.finishDate) {
            alert("Введите обе даты")
        } else if (new Date(this.state.startDate) > new Date(this.state.finishDate)) {
            alert("Дата С должна быть меньше даты ПО")
        } else {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    personalId: Cookies.get('currentOwner'),
                    Start: this.state.startDate,
                    Finish: this.state.finishDate
                })
            };
            const response = await fetch('/Calculation/PeriodSumCalculation', requestOptions);
            const data = await response.json();
            this.setState({ resPeriod: data + ' руб' });
            this.props.values.resPeriod = data + ' руб'
        }
    }
    async componentDidMount() {
        const response = await fetch('/Calculation/GetTariff');
        const data = await response.json();
        this.setState({ tariffs: data })
    }
    async calcYear(e) {
        e.preventDefault();
        if (!this.state.yearCalc) {
            alert('Введите год начислений')
        } else {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ personalId: Cookies.get('currentOwner'), Year: this.state.yearCalc })
            };
            const response = await fetch('/Calculation/YearSumCalculation', requestOptions);
            const data = await response.json();
            this.setState({ resCalcYear: data + ' руб' });
            this.props.values.resCalcYear = data + ' руб'
        }
    }
    async calcMonth(e) {
        e.preventDefault();
        if (!this.state.monthCalc) {
            alert('Введите месяц начисления')
        } else {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ personalId: Cookies.get('currentOwner'), Date: this.state.monthCalc + '-03' })
            };
            const response = await fetch('/Calculation/MonthSumCalculation', requestOptions);
            const data = await response.json();
            this.setState({ resCalcMonth: data + ' руб' });
            this.props.values.resCalcMonth = data + ' руб'
        }
    }
    onStartDateChange(e) {
        this.setState({ startDate: e.target.value });
        this.props.values.startDate = e.target.value
    }
    onFinishDateChange(e) {
        this.setState({ finishDate: e.target.value });
        this.props.values.finishDate = e.target.value
    }
    onYearhCalcChange(e) {
        this.setState({ yearCalc: e.target.value });
        this.props.values.yearCalc = e.target.value
    }
    onMonthCalcChange(e) {
        this.setState({ monthCalc: e.target.value });
        this.props.values.monthCalc = e.target.value
    }
    onTariffChange(e) {
        this.setState({ tariff: e.target.value });
        this.props.values.tariff = e.target.value
    }
    onVolumeChange(e) {
        this.setState({ volume: e.target.value });
        this.props.values.volume = e.target.value
    }
    press() {
        var res = this.state.tariff * this.state.volume
        this.setState({ res: res });
        this.props.values.res = res
    }
    render() {
        console.log(this.state.tariffs)
        return <div >
            <h2>Калькулятор</h2>
            <div className="row calculation">
                <div className="col-7">
                    <div className="calc-tabs">
                        <form onSubmit={this.calcMonth} className="shadow p-4 calc-tab">
                            <h5>Расчет за месяц</h5>
                            <input value={this.state.monthCalc} onChange={this.onMonthCalcChange} type="month" className="form-control" /><span>=</span>
                            <input value={this.state.resCalcMonth} type="text" className="form-control" placeholder="Сумма за месяц" />
                            <button className="btn btn-primary">Рассчитать</button>
                        </form>
                        <form onSubmit={this.calcYear} className="shadow p-4 calc-tab">
                            <h5>Расчет за год</h5>
                            <input onChange={this.onYearhCalcChange} value={this.state.yearCalc} type="text" placeholder="Год" maxLength="4" className="form-control" /><span>=</span>
                            <input value={this.state.resCalcYear} type="text" className="form-control" placeholder="Сумма за год" />
                            <button className="btn btn-primary">Рассчитать</button>
                        </form>
                        <form onSubmit={this.calcPeriod} className="shadow p-4 calc-tab">
                            <h5>Расчет за период</h5>
                            <span>С:</span><input value={this.state.startDate} onChange={this.onStartDateChange} type="date" className="form-control" />
                            <span>По:</span><input value={this.state.finishDate} onChange={this.onFinishDateChange} type="date" className="form-control" />
                            <input value={this.state.resPeriod} type="text" className="form-control" placeholder="Итог" />
                            <button className="btn btn-primary">Рассчитать</button>
                        </form>
                        <div className="shadow p-4 calc-tab">
                            <h5>Расчет по счетчику</h5>
                            <input type="number" value={this.state.tariff} onChange={this.onTariffChange} className="form-control" placeholder="Тариф" />
                            <span>Х</span><input value={this.state.volume} onChange={this.onVolumeChange} type="number" placeholder="Изм. счетчика" className="form-control" />
                            <span>=</span><input value={this.state.res} placeholder="Итог" type="text" className="form-control" />
                            <button onClick={this.press} className="btn btn-primary">Рассчитать</button>
                        </div>
                    </div>
                    <div className="tariffs">
                        <table className="table table-primary table-striped">
                            <thead>
                                <tr>
                                    <th>Тариф</th>
                                    <th>Значение</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.tariffs.map(function (t) {
                                        return <tr>
                                            <td>{t.service.name}</td>
                                            <td>{t.value}</td>
                                        </tr>
                                    })
                                }
                            </tbody>
                        </table>
                    </div>
                </div>
                <div className="col-5">
                    Тут будут выводится счета за те месяцы, которые выраны для рассчетов
                </div>
            </div>
        </div>;
    }
}