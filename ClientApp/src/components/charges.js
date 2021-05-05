import React from 'react';

export default class Charges extends React.Component {
    render() {
        return <div>
            <h1>����������</h1>
            <div className="owner-info">
                <h4>�����������: ������ ���� ��������</h4>
                <h4>���������: �.������ ��.�������� 25, �.15</h4>
            </div>
            <div className="row charge-tabs">
                <div className="col-9 charge-tables">
                    <div className="charge-info shadow charge-table">
                        <div className="service-company">
                            <h5>��������: ��� "������������� ��������"</h5>
                            <h5>�������: 88005553535</h5>
                        </div>
                        <div className="charge">
                            <h6>���� ����������: ������� 2021</h6>
                            <table className="table table-primary">
                                <thead>
                                    <tr>
                                        <th>��� �������</th>
                                        <th>������� ���������</th>
                                        <th>���-�� ��. ���.</th>
                                        <th>������ ����� (���/�� ���.)</th>
                                        <th>���������� ����������</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>��������� � ���</td>
                                        <td>���. �</td>
                                        <td>444</td>
                                        <td>567</td>
                                        <td>4900</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div className="charge-info shadow charge-table">
                        <div className="service-company">
                            <h5>��������: ��� "������� ��������"</h5>
                            <h5>�������: 893290023677</h5>
                        </div>
                        <div className="charge">
                            <h6>���� ����������: ������� 2021</h6>
                            <table className="table table-primary">
                                <thead>
                                    <tr>
                                        <th>��� �������</th>
                                        <th>������� ���������</th>
                                        <th>���-�� ��. ���.</th>
                                        <th>������ ����� (���/�� ���.)</th>
                                        <th>���������� ����������</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>��������� � ���</td>
                                        <td>���. �</td>
                                        <td>444</td>
                                        <td>567</td>
                                        <td>4900</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div className="charge-info shadow charge-table">
                        <div className="service-company">
                            <h5>��������: ��� "������������� ��������"</h5>
                            <h5>�������: 88005553535</h5>
                        </div>
                        <div className="charge">
                            <h6>���� ����������: ������� 2021</h6>
                            <table className="table table-primary">
                                <thead>
                                    <tr>
                                        <th>��� �������</th>
                                        <th>������� ���������</th>
                                        <th>���-�� ��. ���.</th>
                                        <th>������ ����� (���/�� ���.)</th>
                                        <th>���������� ����������</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>��������� � ���</td>
                                        <td>���. �</td>
                                        <td>444</td>
                                        <td>567</td>
                                        <td>4900</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div className="col-3">
                    <h3>������</h3>
                    <form className="charge-form">
                        <span>�:</span><input type="month" className="form-control" />
                        <span>��:</span><input type="month" className="form-control" />
                        <button className="btn btn-primary">������� ��� ����������</button>
                    </form>
                </div>
            </div>
        </div>;
    }
}