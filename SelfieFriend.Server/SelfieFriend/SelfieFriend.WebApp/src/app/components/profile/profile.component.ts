import { Component, Renderer, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MdDialog } from '@angular/material';
import { ModelProfile } from '../../models/model-profile';
import { ProfileWorkService } from '../../services/profile-work';


@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.css'],
    providers: [ProfileWorkService],

})

export class ProfileComponent implements OnInit {
    public access_token = (localStorage.getItem('access_token'));
    public returnUrl: object; // переменная для перенаправления по адресу в случае если нет токена
    public reseivedProfile: ModelProfile; // данные профиля
    constructor(private profielWorkService: ProfileWorkService,
        private router: Router,
        public dialog: MdDialog) { }




    ngOnInit() {
        // необходимо для того чтобы пользователь не смог перейти на этот компонент без токена
        const access_token = (localStorage.getItem('access_token'))
        // условие на проверку токена в localStorage
        if (access_token == null) {
            this.returnUrl = this.router.navigateByUrl('**');
        }

        // подписываемся на получение профиля
        this.profielWorkService.getProfile(access_token)
            .subscribe((response2) => {
                this.reseivedProfile = response2;
            })

    }

}
