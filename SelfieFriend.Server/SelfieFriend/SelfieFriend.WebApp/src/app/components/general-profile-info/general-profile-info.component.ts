import { Component, OnInit } from '@angular/core';
import { ProfileWorkService } from 'app/services/profile-work';
import { ModelProfile } from 'app/models/model-profile';
import { Ng2IzitoastService } from 'ng2-izitoast';
import * as moment from 'moment';


@Component({

    selector: 'app-general-info',
    templateUrl: './general-profile-info.component.html',
    styleUrls: ['./general-profile-info.component.scss'],
    providers: [ProfileWorkService],
})


export class GeneralInfoComponent implements OnInit {
    public moment = moment;
    public profile: ModelProfile = new ModelProfile();
    public plans = []
    public button = false;
    public count = 0;
    public subscribe;
    public isCompleted = true;

    constructor(public _profileservice: ProfileWorkService,
        public iziToast: Ng2IzitoastService) {
    }
    ngOnInit() {
        const access_token = (localStorage.getItem('access_token'))
        this._profileservice.getProfile(access_token).subscribe(response => {
            this.profile = response;
        })

        this._profileservice.getSubscribe().subscribe(response => {
            this.subscribe = response;
            this.isCompleted = false;
        })
    }

    public changeProfile(name, lastname, phone, email, site, about) {
        console.log('dasdas');
        if (this.profile.FirstName !== name|| this.profile.LastName !== lastname ||
            this.profile.Phone !== phone || this.profile.Email !== email ||
            this.profile.Site !== site || this.profile.AboutHim !== about) {
                this.profile.FirstName = name;
                this.profile.LastName = lastname;
                this.profile.Phone = phone;
                this.profile.Email = email;
                this.profile.Site = site;
                this.profile.AboutHim = about;
            this._profileservice.changePostProfile(this.profile).subscribe(response => {
                this.count += 1;
                this.iziToast.success({
                    title: 'Успех!',
                    progressBar: false,
                    message: 'Данные профиля успешно изменены',
                    position: 'topCenter',
                    timeout: 2000,
                })
                if (this.count === 5) {
                    this.iziToast.warning({
                        title: 'Внимание',
                        progressBar: false,
                        message: 'Вы очень часто нажимаете кнопку "Редактировать"',
                        position: 'topCenter',
                        timeout: 2000,
                    })
                }
                if (this.count === 6) {
                    this.iziToast.error({
                        title: 'Ошибка',
                        progressBar: false,
                        message: 'Кнопка заблокирована',
                        position: 'topCenter',
                        timeout: 2000,
                    })
                    this.button = true;
                    setTimeout(() => {
                        this.button = false;
                        this.count = 0;
                    }, 10000);
                }
            })
        } else {
            this.iziToast.warning({
                title: 'Внимание',
                progressBar: false,
                message: 'Вы не изменили поля',
                position: 'topCenter',
                timeout: 2000,
            })
        }
    }
}
