import React from "react"

export default class DownloadCharges extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            File:""
        }
        this.sendFile = this.sendFile.bind(this)
        this.onFileChange = this.onFileChange.bind(this)
    }
    onFileChange(e) {
        this.setState({ File: e.target.value })
    }
    async sendFile(e) {
        e.preventDefault();
        console.log(this.state.File)
            //const requestOptions = {
            //    method: 'POST',
            //    headers: { 'Content-Type': 'application/json' },
            //    body: JSON.stringify({
            //        Login: this.state.Login,
            //        Password: this.state.Password
            //    })
            //};
            //const response = await fetch('/Authorization/AdminAuthorization', requestOptions);
            //const data = await response.json();
            //console.log(data)
            //if (date.IsSuccessfull) {
            //    document.location.href = "/admin/addCharges"
            //} else {
            //    alert(data.Errors[0])
            //}
        
    }
    render() {
        return <div>
            <div className="form shadow">
                <form onSubmit={this.sendFile}>
                    <input onChange={this.onFileChange} type="file" className="form-control" placeholder="Загрузить начисления" />
                    <button className="btn btn-primary">Отправить</button>
                </form>
            </div>
        </div>
    }
}