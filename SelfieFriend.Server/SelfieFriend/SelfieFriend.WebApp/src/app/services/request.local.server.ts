import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ModelOffer } from '../models/model-add-offer';
import { BuyOffering } from '../models/model-buy-offering';
import { ChangeOffer } from '../models/model-change-offer';
import { Params } from '@angular/router';


@Injectable()
export class RequestLocalServer {
    public headers; // хедер для запроса
    public postOfferFile = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/UploadFileApi';
    public postBuyApplication = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/Applications'
    public getTapeNewsPagination = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/GetOfferings?startposition=';
    public postOfferChange = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/OfferChange';
    public postCancelApplication = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/DeleteApplication?offeringId=';
    public getCategoryPhoto = 'http://alexmadar70rus-001-site1.btempurl.com:80/OfferingsCategory'
    public postOffering = 'http://alexmadar70rus-001-site1.btempurl.com:80/api/SaleUploadFileApi'
    public getTapePhoto = 'http://alexmadar70rus-001-site1.btempurl.com:80/SaleOffering/Get'
    public searchPhoto = 'http://alexmadar70rus-001-site1.btempurl.com:80/SaleOffering/GetWithSerach'
    public buyPhoto = 'http://alexmadar70rus-001-site1.btempurl.com:80/offering/buy'
    constructor(private http: Http) {
        // получаем токен с локального хранилища
        const access_token = (localStorage.getItem('access_token'));
        // формируем наш header
        this.headers = new Headers({
            'access_token': localStorage.getItem('access_token'),
            'Content-Type': 'application/json'
        });
    }



    postOffer(obj: ModelOffer) {
        const body = JSON.stringify(obj);
        return this.http.post(this.postOfferFile, body, { headers: this.headers })

    }
    // получаем данные в ленту
    getTape(startpostion: number, count: number) {
        return this.http.get(this.getTapeNewsPagination + startpostion + '&count=' + count, { headers: this.headers })
            .map((res: Response) => res.json()
            );

    }

    // кнопка купить на ленте
    postBuyOffer(obj: BuyOffering) {
        const body = JSON.stringify(obj);
        return this.http.post(this.postBuyApplication, body, { headers: this.headers })

    }
    // редактировать предложение
    postChangeOffer(obj: ChangeOffer) {
        const body = JSON.stringify(obj);
        return this.http.post(this.postOfferChange, body, { headers: this.headers })
    }

    // отмена покупки предложения на ленте

    postCancelOffer(applicationId: number) {
        return this.http.delete(this.postCancelApplication + applicationId, { headers: this.headers })
    }

    getCategory() {
        return this.http.get(this.getCategoryPhoto, { headers: this.headers })
            .map((res: Response) => res.json()
            );
    }

    postPhoto(offering) {
        const body = JSON.stringify(offering);
        return this.http.post(this.postOffering, body, { headers: this.headers })
    }

    getPhoto() {
        return this.http.get(this.getTapePhoto, { headers: this.headers })
            .map((res: Response) => res.json()
            );
    }

    searcPhotos(search, categoryId) {
        return this.http.get(`${this.searchPhoto}?search=${search}&categoryId=${categoryId}`, { headers: this.headers })
            .map((res: Response) => res.json()
            );
    }

    buyPhotos(IdPhoto) {
        return this.http.post( `${this.buyPhoto}?offeringId=${IdPhoto}`, { headers: this.headers })
    }

}
