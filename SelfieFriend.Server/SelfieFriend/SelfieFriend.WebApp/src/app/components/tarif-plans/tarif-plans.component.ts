import { Component, OnInit } from '@angular/core';
import { ProfileWorkService } from 'app/services/profile-work';

@Component({
    selector: 'app-tarif-plans',
    templateUrl: './tarif-plans.component.html',
    styleUrls: ['./tarif-plans.component.scss'],
})
export class TarifPlanComponent implements OnInit {
    public plans;
    constructor(public _profileservice: ProfileWorkService) { }

    ngOnInit() {
        this._profileservice.getPlans().subscribe(response => {
            this.plans = response;
            console.log(response);
        })
    }

    public subscribePlan(plan) {
        this._profileservice.postSubscribePlanUser(plan.Id).subscribe(response => {
            console.log(response);
        })
    }

}
