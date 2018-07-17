import { RequestOptions, Headers, Http } from "@angular/http";
import { Observable, BehaviorSubject } from 'rxjs/Rx';
import { Injectable } from "@angular/core";
import { LocalStorage } from '@ngx-pwa/local-storage';

@Injectable()

export class UserService {

    baseUrl: string = 'http://localhost:55833/api';
    private loggedIn = false;

    constructor(private http: Http, private localStorage: LocalStorage) {
        this.localStorage.getItem('auth_token').subscribe(data => {
            this.loggedIn = data !== null;
        });
    }

    register(name: string, surname: string, email: string, phone: string, adress: string, login: string, password: string) {
        let body = JSON.stringify({ name, surname, email, phone, adress, login, password });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.baseUrl + "/Account", body, options)
            .map(res => true)
            .catch(this.handleError);
    }

    private _authNavStatusSource = new BehaviorSubject<boolean>(false);
    authNavStatus$ = this._authNavStatusSource.asObservable();


    login(userName: string, password: string) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http
            .post(
                this.baseUrl + '/Auth/login',
                JSON.stringify({ userName, password }), { headers }
            )
            .map(res => res.json())
            .map(res => {
                this.localStorage.setItem('auth_token', res.auth_token).subscribe(data => {
                    this.loggedIn = true;
                    this._authNavStatusSource.next(true);
                });

                //ustawiamy w local storage id obecnie zalogowanego uzytkownika, potem pobierajmy to id ze storage
                //pobrac jakoś wartość z json lub przeksztalcic na objekt               
                this.localStorage.setItem('id', res.id);
                return true;
            })
            .catch(this.handleError);
    }

    logout() {
        this.localStorage.removeItem('auth_token').subscribe(obj => {
            this.loggedIn = false;
            this._authNavStatusSource.next(false);
        });

    }

    isLoggedIn() {
        return this.loggedIn;
    }

    protected handleError(error: any) {
        var applicationError = error.headers.get('Application-Error');

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
        return Observable.throw(modelStateErrors || 'Błąd serwera');
    }
}