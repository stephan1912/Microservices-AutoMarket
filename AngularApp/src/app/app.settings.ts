import { Injectable } from '@angular/core';
import { NgxUiLoaderService } from 'ngx-ui-loader';
@Injectable()
export class AppSettings {
    public baseUrl: string = "http://localhost:60162/";
    public baseApiUrl: string = "http://localhost:60162/api/v1/";
    public lsUserDataKey: string = "userData";
    public lsAccountAddressExpiration: number = 30 * 60 * 1000; //30 mins in milisecs
}