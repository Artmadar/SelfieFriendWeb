import { Component } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';
import { MyOfferings } from '../../models/model-my-offer';
import { ProfileWorkService } from '../../services/profile-work';
import { DialogPreview } from '../modal-windows/dialog-preview-image/dialog.preview.component';
import { DialogResult } from '../modal-windows/dialog-result/dialog-result.component';



@Component({
    selector: 'profile-my-offers',
    templateUrl: './profile-my-offers.component.html',
    styleUrls: [],
    providers: [ProfileWorkService],
})

export class ProfileMyOffers {
    Profile = true; // для Dialog
    proverka= true;
    pusto=false;
    constructor(private profileWorkService: ProfileWorkService,
        public dialog: MdDialog) {
        for (let i = 1; i <= this.reseivedMyOfferings.length; i++) {
            this.reseivedMyOfferings.push();
        }

    }
    reseivedMyOfferings: Array<MyOfferings> = []; // данные "Мои Предложения"

    ngOnInit() {
        // получаем "Мои Предложения"
        this.profileWorkService.getMyOffers().subscribe((response) => {

            this.reseivedMyOfferings = response;
            if(response==[])
                {
                    this.pusto=false;
                }
        })

    }
    openDialog(PhotoPath: string) {
        const dialogRef = this.dialog.open(DialogPreview, {
            data: PhotoPath
        });
    }
    OpenDialogEdit(OfferingId: number, Description: string, Title: string, Price: string, Profile: boolean) {
        const dialogRef = this.dialog.open(DialogResult, {
            data: [{
                Id: OfferingId,
                Description: Description,
                Title: Title,
                Cost: Price,
                Profile: Profile,
            }]
        });
    }

    deleteOffer(applicationId: number) {
        const ID = applicationId;
        this.profileWorkService.deleteOffer(ID).subscribe((response) => {
            console.log(response);
            location.reload();
            if (response.ok)
            {
                this.proverka = false;
            }
        })

    }
}
