import React from "react"

export default class PersonalNumber extends React.Component {
    render() {
        return <div>
            <div className="form shadow">
                <h2>������� ������� ����</h2>
                <form>
                    <input maxLength="9" className="form-control" placeholder="������� ����" />
                    <div id="passwordHelpBlock" className="form-text">
                        ��� ������� ���� ��� ������������� �����
                            </div>
                    <button className="btn btn-primary">����������</button>
                </form>
            </div>
        </div>
    }
}