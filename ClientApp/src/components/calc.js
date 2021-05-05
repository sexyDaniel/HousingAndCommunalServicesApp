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
            <h2>�����������</h2>
            <div className="row calculation">
                <div className="col-6 calc-tabs">
                    <form className="shadow p-4 calc-tab">
                        <h5>������ �� �����</h5>
                        <input type="month" className="form-control" /><span>=</span>
                        <input type="text" className="form-control" placeholder="����� �� �����" />
                        <button className="btn btn-primary">����������</button>
                    </form>
                    <form className="shadow p-4 calc-tab">
                        <h5>������ �� ���</h5>
                        <input type="text" placeholder="���" maxLength="4" className="form-control" /><span>=</span>
                        <input type="text" className="form-control" placeholder="����� �� ���" />
                        <button className="btn btn-primary">����������</button>
                    </form>
                    <form className="shadow p-4 calc-tab">
                        <h5>������ �� ������</h5>
                        <span>�:</span><input type="month" className="form-control" />
                        <span>��:</span><input type="month" className="form-control" />
                        <input type="text" className="form-control" placeholder="����" />
                        <button className="btn btn-primary">����������</button>
                    </form>
                    <div className="shadow p-4 calc-tab">
                        <h5>������ �� ��������</h5>
                        <input type="number" value={this.state.tariff} onChange={this.onTariffChange} className="form-control" placeholder="�����" />
                        <span>�</span><input value={this.state.volume} onChange={this.onVolumeChange} type="number" placeholder="���. ��������" className="form-control" />
                        <span>=</span><input value={this.state.res} placeholder="����" type="text" className="form-control" />
                        <button onClick={this.press} className="btn btn-primary">����������</button>
                    </div>
                </div>
                <div className="col-2 tariff">
                    <table className="table table-primary table-striped">
                        <thead>
                            <tr>
                                <th>�����</th>
                                <th>��������</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>��������� � ���</td>
                                <td>100</td>
                            </tr>
                            <tr>
                                <td>������� ����</td>
                                <td>1200</td>
                            </tr>
                            <tr>
                                <td>�������� ����</td>
                                <td>1000</td>
                            </tr>
                            <tr>
                                <td>���������</td>
                                <td>300</td>
                            </tr>
                            <tr>
                                <td>���</td>
                                <td>12000</td>
                            </tr>
                            <tr>
                                <td>�������������</td>
                                <td>12000</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div className="col-4">
                    ��� ����� ��������� ����� �� �� ������, ������� ������ ��� ���������
                        </div>
            </div>
        </div>;
    }
}