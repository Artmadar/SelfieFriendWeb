import { Component, OnInit, ViewChild, AfterViewChecked } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { CgOverlay } from 'ngx-crystal-gallery/components';

@Component({

    selector: 'app-welcome',
    templateUrl: './welcome.component.html',
    styleUrls: ['./welcome.component.scss'],
})

export class WelcomeComponent implements OnInit {
    public pageNumber = 0;
    public pageCount = 0;
    public pages = [
        {
            title: 'Рассматривайте профессиональные стоковые фотографии.',
            image: 'http://bipbap.ru/wp-content/uploads/2017/09/Cool-High-Resolution-Wallpaper-1920x1080.jpg'
        },
        {
            title: 'Найдите потрясающие материалы для вашего проекта.',
            image: 'http://mirpozitiva.ru/uploads/posts/2016-08/1472042938_27.jpg'
        },
        {
            title: 'Окунитесь в мир прекрасных фотографий. Обновления каждый день.',
            image: 'http://www.radionetplus.ru/uploads/posts/2013-04/1365401196_teplye-oboi-1.jpeg'
        },
        {
            title: 'Мы работает над тщательным отбором фотографий чтобы удивлять вас.',
            image: 'http://fonday.ru/images/tmp/16/2/original/16216PQJIjqxRiCkOMlWBbNnLS.jpg'
        }
    ];
    galleryOptions: NgxGalleryOptions[];
    galleryImages: NgxGalleryImage[];
    myImages: any = [
        {
            preview: 'http://bipbap.ru/wp-content/uploads/2017/09/Cool-High-Resolution-Wallpaper-1920x1080.jpg',
            full: 'http://bipbap.ru/wp-content/uploads/2017/09/Cool-High-Resolution-Wallpaper-1920x1080.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'http://minionomaniya.ru/wp-content/uploads/2016/01/%D0%BC%D0%B8%D0%BD%D1%8C%D0%BE%D0%BD%D1%8B-%D0%BF%D1%80%D0%B8%D0%BA%D0%BE%D0%BB%D1%8B-%D0%BA%D0%B0%D1%80%D1%82%D0%B8%D0%BD%D0%BA%D0%B8.jpg',
            full: 'http://minionomaniya.ru/wp-content/uploads/2016/01/%D0%BC%D0%B8%D0%BD%D1%8C%D0%BE%D0%BD%D1%8B-%D0%BF%D1%80%D0%B8%D0%BA%D0%BE%D0%BB%D1%8B-%D0%BA%D0%B0%D1%80%D1%82%D0%B8%D0%BD%D0%BA%D0%B8.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'http://mirpozitiva.ru/uploads/posts/2016-09/1474011210_15.jpg',
            full: 'http://mirpozitiva.ru/uploads/posts/2016-09/1474011210_15.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'https://i.ytimg.com/vi/ywun2xs7-B4/maxresdefault.jpg',
            full: 'https://i.ytimg.com/vi/ywun2xs7-B4/maxresdefault.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'http://bipbap.ru/wp-content/uploads/2017/04/187604chan1309313071950.jpg',
            full: 'http://bipbap.ru/wp-content/uploads/2017/04/187604chan1309313071950.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'http://mirpozitiva.ru/uploads/posts/2016-08/1472042868_26.jpg',
            full: 'http://mirpozitiva.ru/uploads/posts/2016-08/1472042868_26.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'http://mirpozitiva.ru/uploads/posts/2016-10/1476433739_04.jpg',
            full: 'http://mirpozitiva.ru/uploads/posts/2016-10/1476433739_04.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'http://fonday.ru/images/tmp/14/6/original/14616kstwExQLKlbCfnRdr.jpg',
            full: 'http://fonday.ru/images/tmp/14/6/original/14616kstwExQLKlbCfnRdr.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'http://goodimg.ru/img/kartinki-priroda-skachat-besplatno3.jpg',
            full: 'http://goodimg.ru/img/kartinki-priroda-skachat-besplatno3.jpg',
            width: 1000,
            height: 669
        },
        {
            preview: 'https://i.ytimg.com/vi/JtyZXwdmkgs/maxresdefault.jpg',
            full: 'https://i.ytimg.com/vi/JtyZXwdmkgs/maxresdefault.jpg',
            width: 1000,
            height: 669
        },
    ];
    myConfig: any = {
        masonry: true,
        masonryMaxHeight: 200,
        masonryGutter: 3,
        loop: true,
        opacity: 2,
    };
    constructor(private overlay: CgOverlay) {

    }


    ngOnInit() {
    }
}
