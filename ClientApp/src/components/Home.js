import React from 'react';

export default class Home extends React.Component {
    render() {
        return <div>
            <div className="main-info">
                <h1>Система просмотра ЖКУ</h1>
                <ul class="list-group">
                    <li class="list-group-item list-group-item-primary"><h3>Коротко о системе</h3></li>
                    <li class="list-group-item">Просмотр всех начислений за выбранный период</li>
                    <li class="list-group-item">Возможность перерасчета в калькуляторе</li>
                    <li class="list-group-item">Доступен список всех обслуживающих компаний вашего дома</li>
                    <li class="list-group-item"><span class="badge bg-warning text-dark">Возможно</span>: Графики для просмотра динамики начислений</li>
                </ul>
            </div>
        </div>;
    }
}