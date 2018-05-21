import { ImageResult, ResizeOptions } from 'ng2-imageupload';
import { Component, OnInit } from '@angular/core';
import { ApplicationUser } from '../../models/model-application-for-user';
import { UploadImagePro } from '../../models/model-upload-profile';
import { ProfileWorkService } from '../../services/profile-work';



@Component({
    selector: 'profile-applications-for-me',
    templateUrl: './profile-applications-for-me.html',
    providers: [ProfileWorkService],
})

export class ProfileApplicatonsForMe implements OnInit {

    reseivedApplicationUser: Array<ApplicationUser>= []; // данные "Заявки Мне"
    upload: UploadImagePro = new UploadImagePro(); // модель для отправки на сервер
    pusto = false;
    src = ''; // путь картинки
    private base64textString = '';  // здесь хранится картинка в формате base64
    proverka: boolean;
    applicationid: number;
    uploaded= false;

    constructor(private profileWorkService: ProfileWorkService) {
         for (let i = 1; i <= this.reseivedApplicationUser.length; i++) {
            this.reseivedApplicationUser.push();
        }
     }


    // tslint:disable-next-line:use-life-cycle-interface
    ngOnInit() {
        this.profileWorkService.getApplicationForUser().subscribe((response) => {
            this.reseivedApplicationUser = response;
            if (response == []) {
                    this.pusto = true;
                }
        })
    }

    // отслеживаем выбранный файл
    OnSelectedImage(imageResult: ImageResult) {
        this.src = imageResult.dataURL;

        const photo = imageResult.file;
        if (photo) {
            const reader = new FileReader();
            reader.onload = this._handleReaderLoaded.bind(this);
            reader.readAsBinaryString(photo);
        }
    }


    // base64
    _handleReaderLoaded(readerEvt) {
        const binaryString = readerEvt.target.result;
        this.base64textString = btoa(binaryString);
        console.log(this.base64textString);
    }
    // отправка картинки по предложению
    submit(applicationUser: ApplicationUser) {
        this.applicationid = applicationUser.ApplicationId;
        this.upload.ApplicationId = applicationUser.ApplicationId;
        this.upload.Photo = this.base64textString;
        if (this.upload.Photo === '' || this.upload.Photo == null) {
            this.proverka = true;
        } else
        {
            this.proverka = false;
        this.profileWorkService.postImage(this.upload).subscribe((response) => {
            if (response.ok) {
                console.log(response);
                applicationUser.Uploaded = true;
            }

        });

}
    }
}
