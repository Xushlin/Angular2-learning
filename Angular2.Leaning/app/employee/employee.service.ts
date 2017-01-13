import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { Http, Response,Headers, RequestOptions } from '@angular/http';
import { Observable }  from 'rxjs/Observable';
import { AppService } from '../app.service'
import 'rxjs/add/operator/map';


@Injectable()
export class EmployeeService{
    employees: Employee[]=[];
    private employeeUrl:string;

    constructor (private http: Http, private appService:AppService ) {
     this.employeeUrl = this.appService.apiUrl()+'employees';
    }


    getAllEmployees():Observable<Employee[]> {
        return this.http.get(this.employeeUrl).map(this.extractData)
            .catch(this.handleError);
    }
    addEmployee(employee: Employee): Observable<Employee>{
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.employeeUrl+"/add", employee, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    deleteEmployeeById(id: string): Observable<Employee>{
        return this.http.delete(this.employeeUrl+"/"+id).map(this.extractData)
            .catch(this.handleError);
    }

    updateEmployeeById(employee:Employee): Observable<Employee>{
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(this.employeeUrl+"/update",employee,options).map(this.extractData).catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body as Employee[] || { } ;
    }
    private handleError (error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

    getEmployeeById(id: string):Observable<Employee>{
        return this.http.get(this.employeeUrl+"/"+id)
            .map(this.extractData)
            .catch(this.handleError);
    }

    search(term:string):Observable<Employee[]>{
        return this.http.get(this.employeeUrl+"/"+term).map(this.extractData)
            .catch(this.handleError);
    }
    toggleEmployeeComplete(employee: Employee){
         return null;
    }

}