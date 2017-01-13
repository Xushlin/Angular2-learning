/**
 * Created by michael on 1/13/2017.
 */

import { Injectable } from '@angular/core';

@Injectable()
export class AppService{
    apiUrl(){
        return "http://localhost:1079/api/";
    }
}
