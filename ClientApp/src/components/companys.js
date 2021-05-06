import React from "react"

export default class Companys extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            companys: []
        }
        
    }
    async componentDidMount() {
        const response = await fetch('/Organization/GetAllServiceCompanies');
        const data = await response.json();
        console.log(data)
        this.setState({ companys: data })
    }
    render() {
        return <div>
            <h2>Вас обслуживают</h2>
            <ul className="company_list">
                {
                    this.state.companys.map(function (c) {
                        return <li className="shadow">
                            <h4>{c.service.name }</h4>
                            <div className="company-info">
                                <p>Название: {c.name}</p>
                                <p>Телефон: {c.phone}</p>
                                <p>Email: {c.email}</p>
                            </div>
                        </li>
                    })
                }
            </ul>
        </div>
    }
}  