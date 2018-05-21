import { Injectable } from '@angular/core';
import { Http, Jsonp } from '@angular/http';
import { Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { UploadImagePro } from '../models/model-upload-profile';
import { DownloadImage } from '../models/model-download-image';

@Injectable()

export class ProfileWorkService {
    public headers; // хедер для запроса
    private readonly getProfileUser = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/Users';
    private readonly getOffers = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/MyOfferings';
    private readonly getApplication = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/GetUserApplications';
    private readonly getApplicationUser = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/GetApplicationForUser';
    private readonly postImages = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/sendPurchase'
    private readonly postPayApplication = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/PayPurchase?applicationId=';
    private readonly getDownloadImage = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/GetPhoto?applicationId='
    private readonly deleteMyOffer = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/CloseOffering?offeringId=';
    private readonly changeProfile = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/Users/ChangeInfo'
    private readonly getSubscribePlan = 'http://alexmadar70rus-001-site1.btempurl.com:80/GetSubscribePlans'
    private readonly getSubscribeForUser = 'http://alexmadar70rus-001-site1.btempurl.com:80/GetSubscribe'
    private readonly postSubscribePlan = 'http://alexmadar70rus-001-site1.btempurl.com/Subscribe?id=1'

    constructor(private http: Http) {
        // получаем токен с локального хранилища
        const access_token = (localStorage.getItem('access_token'));
        // формируем наш header
        this.headers = new Headers({
            'access_token': localStorage.getItem('access_token'),
            'Content-Type': 'application/json'
        });
    }
    // получаем профиль
    getProfile(access_token) {
        const headers = new Headers({
            'access_token': localStorage.getItem('access_token'),
            'Content-Type': 'application/json'
        });
        return this.http.get(this.getProfileUser, { headers: headers })
            .map((res: Response) => res.json()
            );


    }
    // Профиль, "Мои предложения"
    getMyOffers() {

        return this.http.get(this.getOffers, { headers: this.headers })
            .map((res: Response) => res.json()
            );

    }
    // Профиль, "Мои заявки"
    getMyApplication() {
        return this.http.get(this.getApplication, { headers: this.headers })
            .map((res: Response) => res.json()
            );

    }
    // Профиль, "Заявки мне"
    getApplicationForUser() {
        return this.http.get(this.getApplicationUser, { headers: this.headers })
            .map((res: Response) => res.json()
            );

    }
    // отправляем id предложения и картинку нужно для вкладки "Заявки мне"
    postImage(obj: UploadImagePro) {
        const body = JSON.stringify(obj);
        return this.http.post(this.postImages, body, { headers: this.headers })


    }
    // Запрос для кнопки "Оплатить", вкладка "Мои заявки"
    postPay(applicationId: number) {
        return this.http.post(this.postPayApplication + applicationId, null, { headers: this.headers })

    }
    // Запрос для загрузки изображения, вкладка "Мои заявки"
    downloadImage(applicationId: number) {
        return this.http.get(this.getDownloadImage + applicationId, { headers: this.headers })
            .map((res: Response) => res.json() as DownloadImage
            );
    }
    // Запрос для удаления моего предложения
    deleteOffer(applicationId: number) {
        return this.http.delete(this.deleteMyOffer + applicationId, { headers: this.headers })
    }
    // Редактирование профиля
    changePostProfile(profile) {
        return this.http.post(this.changeProfile, profile, { headers: this.headers })
    }

    getPlans() {
        return this.http.get(this.getSubscribePlan, { headers: this.headers })
            .map((res: Response) => res.json()
            );
    }

    getSubscribe() {
        return this.http.get(this.getSubscribeForUser, { headers: this.headers })
            .map((res: Response) => res.json()
            );
    }

    postSubscribePlanUser(idPlan) {
        const headers = new Headers({
            'access_token': localStorage.getItem('access_token'),
            'Content-Type': 'application/json'
        });
        return this.http.post(`${this.postSubscribePlan}?id=` + idPlan, { headers: headers })
    }
}
