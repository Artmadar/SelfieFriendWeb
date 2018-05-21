import { Component, ElementRef, ViewChild } from '@angular/core';
import { ProfileWorkService } from '../../services/profile-work';
import { MyApplication } from '../../models/model-my-applications';

@Component({
    selector: 'profile-my-applications',
    templateUrl: './profile-my-applications.component.html',
    providers: [ProfileWorkService]
})

export class ProfileMyApplications {
    // это наш элемент html "<a></a>"
    @ViewChild('DowFile') DowFile: ElementRef;
    applicationid: number;
    proverka= true;
    pusto=false;

    reseivedMyApplication: Array<MyApplication> = []; // данные "Мои Заявки"
    constructor(private profileWorkService: ProfileWorkService) {
        for (let i = 1; i <= this.reseivedMyApplication.length; i++) {
            this.reseivedMyApplication.push();
        }
    }


    ngOnInit() {   // получение Моих Заявок
        this.profileWorkService.getMyApplication().subscribe((response) => {
            this.reseivedMyApplication = response;
            if(response==[])
                {
                    this.pusto=true;
                }
        })
    }

    // кнопка оплатить
    PayOffer(application: MyApplication) {
        // var ID = applicationId;
        this.applicationid = application.ApplicationId;

        this.profileWorkService.postPay(this.applicationid).subscribe((response) => {
               this.proverka = false;
            if (response.ok)
            {
                application.ReadyToDownload = true;
            }
        })

    }
    // скачивание изображения
    DownloadImage(applicationId: number) {
        const ID = applicationId;
        this.profileWorkService.downloadImage(ID).subscribe((response) => {
            const event = new MouseEvent('click', { bubbles: true });
            // присваиваем явно нашему элементу ссылку на картинку которая приходит с сервера
            this.DowFile.nativeElement.href = response.ImagePath;
            this.DowFile.nativeElement.click()
        });
    }
}
