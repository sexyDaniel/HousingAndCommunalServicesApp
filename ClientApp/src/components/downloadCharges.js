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
        console.log(e.target.files[0])
        this.setState({ File: e.target.files })
    }
    async sendFile(e) {
        e.preventDefault();
        console.log(this.state.File)
        var f = new FormData();
        
        f.append("File", this.state.File[0])
        const requestOptions = {
            type: 'uploadAll',
            method: 'POST',
            headers: {
                'Content-Type': 'multipart/form-data',
                'Accept': '*/*'
            },
            body: { uploadedFile:this.state.File[0] }
        };
        const response = await fetch('/ChargeCSV/AddNewCSV', requestOptions);
        const data = await response.json();
        console.log(data) 
    }
    render() {
        return <div>
            <div className="form shadow">
                <h6>Пока не работает</h6>
                <form onSubmit={this.sendFile} encType="multipart/form-data">
                    <input onChange={this.onFileChange} type="file" className="form-control" placeholder="Загрузить начисления" />
                    <button className="btn btn-primary">Отправить</button>
                </form>
            </div>
        </div>
    }
}