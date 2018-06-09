import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

import { UserService } from '../../services/UserService';
import { UserRegistration } from '../../models/UserRegistration';

@Component({
    selector: 'register',
    templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

    ngOnInit(): void {
        
    }

    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;

    private confirmPass: boolean;

    constructor(private userService: UserService, private router: Router) { }

    registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';

        //if (value.password != value.confirm)
        //    this.confirmPass


        if (valid)
        {
            this.userService.register(value.name, value.surname, value.email, value.phone, value.adress, value.login, value.password)
                .finally(() => this.isRequesting = false)
                .subscribe(
                result =>
                {
                    if (result)
                    {
                        this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
                    }
                },
                errors => this.errors = errors);
        }
    }
}
