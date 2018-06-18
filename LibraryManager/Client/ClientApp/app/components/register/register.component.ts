import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

import { UserService } from '../../services/user.service';
import { UserRegistration } from '../../models/UserRegistration';

@Component({
    selector: 'register',
    templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

    ngOnInit(): void {
        
    }

    errors: string[] = [];

    isRequesting: boolean;
    submitted: boolean = false;

    private notEmptyValue: boolean;
    private confirmPass: boolean;
    private validEmail: boolean;
    private regexpEmailValidation = new RegExp('^[^\s@]+@[^\s@]+\.[^\s@]{2,}$');
    private validPhone: boolean;
    private regexpPhoneValidation = new RegExp("(\-?[0-9]){9}");
    
    constructor(private userService: UserService, private router: Router) { }

    registerUser({ value }: { value: UserRegistration }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = [];

        if (value.name === '' ||
            value.surname === '' ||
            value.email === '' ||
            value.phone === '' ||
            value.adress === '' ||
            value.login === '' ||
            value.password === '') {
            this.notEmptyValue = false;
        }
        else {
            this.notEmptyValue = true;
        }


        if (value.password != value.confirm)
            this.confirmPass = false;
        else
            this.confirmPass = true;

        this.validEmail = this.regexpEmailValidation.test(value.email);
        this.validPhone = this.regexpPhoneValidation.test(value.phone);

        if (this.notEmptyValue && this.confirmPass && this.validEmail && this.validPhone) {
            this.userService.register(value.name, value.surname, value.email, value.phone, value.adress, value.login, value.password)
                .finally(() => this.isRequesting = false)
                .subscribe(
                    result => {
                        if (result) {
                            this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
                        }
                    },
                    errors => this.errors.push(errors));
        }
        else {
            if (!this.notEmptyValue) {              
                this.errors.push('Jedno lub kilka pól formularza nie zostało uzupełnione.');
                this.isRequesting = false;
            }
            if (!this.validEmail) {                
                this.errors.push('Wartość wprowadzona w polu email nie jest prawidłowym adresem email.');
                this.isRequesting = false;
            }
            if (!this.validPhone) {
                this.errors.push('Wprowadzony numer telefonu nie jest prawidłowy.');
                this.isRequesting = false;
            }
            if (!this.confirmPass) {
                this.errors.push('Hasło nie zostało prawidłowo potwierdzone.');
                this.isRequesting = false;
            }
        }
        
    }
}
