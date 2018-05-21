import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ModelToken } from '../models/model-token';


@Injectable()
export class AuthService {

    private readonly tokenPost = 'http://alexmadar70rus-001-site1.btempurl.com/api/authorize/';
    // tslint:disable-next-line:max-line-length
    private readonly authVk = 'https://oauth.vk.com/access_token?client_id=6082258&redirect_uri=http://localhost:4200/accesstoken&client_secret=uIKCEJLAI6Dnl4rmOCvl&code='
    constructor(private http: Http) {

    }

    getAccess_token(code: string) {   // посылаем запрос для токена
        return this.http.get(this.authVk + code)
            .map((res: Response) => res.json() as ModelToken
            );
    }

    postToken(model: ModelToken) {   // берем данные с модели
        const modelSendLocal = {
            access_token: model.access_token
        }
        // посылаем данные на локальный сервер
        return this.http.post(this.tokenPost + modelSendLocal.access_token, null);

    }

    // пытаемся сохранить токен
    savetoken(Token: ModelToken) {
        localStorage.setItem('access_token', Token.access_token);

    }
}
