import React from 'react';

export default class Calc extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            tariff: this.props.values.tariff,
            volume: this.props.values.volume,
            res: this.props.values.res
        }
        this.press = this.press.bind(this);
        this.onTariffChange = this.onTariffChange.bind(this)
        this.onVolumeChange = this.onVolumeChange.bind(this)
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
        // let {tariff, volume, res} = this.props.values;
        // // console.log(this.props.onTariffChange());
        // let onVolumeChange = this.props.onVolumeChange;
        // let onTariffChange = this.props.onTariffChange;
        return <div >
            <h2>Калькулятор</h2>
            <div className="row calculation">
                <div className="col-6 calc-tabs">
                    <form className="shadow p-4 calc-tab">
                        <h5>Расчет за месяц</h5>
                        <input type="month" className="form-control" /><span>=</span>
                        <input type="text" className="form-control" placeholder="Сумма за месяц" />
                        <button className="btn btn-primary">Рассчитать</button>
                    </form>
                    <form className="shadow p-4 calc-tab">
                        <h5>Расчет за год</h5>
                        <input type="text" placeholder="Год" maxLength="4" className="form-control" /><span>=</span>
                        <input type="text" className="form-control" placeholder="Сумма за год" />
                        <button className="btn btn-primary">Рассчитать</button>
                    </form>
                    <form className="shadow p-4 calc-tab">
                        <h5>Расчет за период</h5>
                        <span>С:</span><input type="month" className="form-control" />
                        <span>По:</span><input type="month" className="form-control" />
                        <input type="text" className="form-control" placeholder="Итог" />
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
                <div className="col-2 tariff">
                    <table className="table table-primary table-striped">
                        <thead>
                            <tr>
                                <th>Тариф</th>
                                <th>Значение</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Обращение с ТКО</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>Горячая вода</td>
                                <td>1200</td>
                            </tr>
                            <tr>
                                <td>Холодная вода</td>
                                <td>1000</td>
                            </tr>
                            <tr>
                                <td>Капремонт</td>
                                <td>300</td>
                            </tr>
                            <tr>
                                <td>Газ</td>
                                <td>12000</td>
                            </tr>
                            <tr>
                                <td>Электричество</td>
                                <td>12000</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div className="col-4">
                    Тут будут выводится счета за те месяцы, которые выраны для рассчетов
                        </div>
            </div>
        </div>;
    }
}