import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { ModelProfile } from 'app/models/model-profile';

@Injectable()
export class DataSevice {
    public profileSource = new BehaviorSubject<ModelProfile>(null);
    public currentProfile = this.profileSource.asObservable();

    public changeProfile(profile: ModelProfile) {
        this.profileSource.next(profile);
    }
}
