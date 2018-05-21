import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params, RouterModule } from '@angular/router';
import { Http, Headers } from '@angular/http';

import { AuthService } from '../../services/auth-service';
import { ModelToken } from '../../models/model-token';


@Component({

    selector: 'access-token',
    templateUrl: './access-token-component.html',
    providers: [AuthService]

})

export class AccessToken {
    returnUrl: any;
    modtoken: ModelToken; // объект модели
    public showContent = false;

    constructor(private activatedRoute: ActivatedRoute,
        private router: Router,
        private authServise: AuthService) { }

    // для посылки на сервер
    autorise(modtoken: ModelToken) {
        this.authServise.postToken(modtoken).subscribe((responce) => {
            // если ответ ОК
            if (responce.statusText = 'OK') {
                this.returnUrl = this.router.navigateByUrl('tape');
                setTimeout(() => this.showContent = true, 3000);
            } else {
                this.returnUrl = this.router.navigateByUrl('**');

            }

        }, (err: any) => {
            this.returnUrl = this.router.navigateByUrl('**');
        })

    }

    ngOnInit() {
        // считываем из браузера код
        this.activatedRoute.queryParams.subscribe((params: Params) => {
            let code = params['code'];
            // получаем аксес токен
            this.authServise.getAccess_token(code).subscribe((response) => {
                let models = response as ModelToken;
                this.autorise(models);
                // для сохранения токена
                this.authServise.savetoken(models);
            })
        })

    }
}