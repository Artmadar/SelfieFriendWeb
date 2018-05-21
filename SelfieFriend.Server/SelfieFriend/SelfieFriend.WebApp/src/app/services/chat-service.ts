import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';


@Injectable()
export class ChatService {
    public headers; // хедер для запроса
    constructor(private http: Http) {
        // получаем токен с локального хранилища
        const access_token = (localStorage.getItem('access_token'));
        // формируем наш header
        this.headers = new Headers({
            'access_token': localStorage.getItem('access_token'),
            'Content-Type': 'application/json'
        });
    }
    // получаем данные в ленту
    getTape() {
        return this.http.get('http://alexartma-001-site1.etempurl.com/api/Offerings', { headers: this.headers })
            .map((res: Response) => res.json()
            );
    }
}
