import { RequestOptions, Headers, Http } from "@angular/http";
import { Observable } from 'rxjs/Rx';
import { Injectable } from "@angular/core";

@Injectable()

export class UserService {

    baseUrl: string = 'http://localhost:55833/api';
    private loggedIn = false;

    constructor(private http: Http) {
        
        };

    register(name: string, surname: string, email: string, phone: string, adress: string, login: string, password: string) {
        let body = JSON.stringify({ name, surname, email, phone, adress, login, password });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.baseUrl + "/Account", body, options)
            .map(res => true)
            .catch(this.handleError);
    }

    protected handleError(error: any) {
        var applicationError = error.headers.get('Application-Error');

        // either applicationError in header or model error in body
        if (applicationError) {
            return Observable.throw(applicationError);
        }

        var modelStateErrors: string = '';
        var serverError = error.json();

        if (!serverError.type) {
            for (var key in serverError) {
                if (serverError[key])
                    modelStateErrors += serverError[key] + '\n';
            }
        }

        modelStateErrors = modelStateErrors = '' ? '' : modelStateErrors;
        return Observable.throw(modelStateErrors || 'Server error');
    }
}