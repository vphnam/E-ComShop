import { AbstractControl, FormGroupDirective, NgForm } from "@angular/forms";
import { ErrorStateMatcher } from "@angular/material/core";

export class CustomErrorStateMatcher implements ErrorStateMatcher{
    isErrorState(control: AbstractControl | null, form: FormGroupDirective | NgForm | null): boolean {
        if(control?.touched && control.errors?.["required"])
            return control?.touched && control.errors?.["required"];
        else if(control?.touched && control.errors?.["maxlength"])
            return true;
        else if(control?.touched && control.errors?.["minlength"])
            return true;
        else if(control?.touched && control.errors?.["pattern"])
            return true;
        else if(control?.touched && control.errors?.["email"])
            return true;
        else
            return false;
    }
}