import React from 'react';

export default class Home extends React.Component {
    render() {
        return <div>
            <div className="main-info">
                <h1>������� ��������� ���</h1>
                <ul class="list-group">
                    <li class="list-group-item list-group-item-primary"><h3>������� � �������</h3></li>
                    <li class="list-group-item">�������� ���� ���������� �� ��������� ������</li>
                    <li class="list-group-item">����������� ����������� � ������������</li>
                    <li class="list-group-item">�������� ������ ���� ������������� �������� ������ ����</li>
                    <li class="list-group-item"><span class="badge bg-warning text-dark">��������</span>: ������� ��� ��������� �������� ����������</li>
                </ul>
            </div>
        </div>;
    }
}
