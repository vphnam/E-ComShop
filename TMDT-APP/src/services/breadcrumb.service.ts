import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
@Injectable({
    providedIn: 'root'
})
export class BreadCrumbService {
    private titleSubject!: BehaviorSubject<string>;
    public title!: Observable<string>;

    private sessionSubject!: BehaviorSubject<string>;
    public session!: Observable<string>;
    constructor( ) {
        this.titleSubject = new BehaviorSubject<string>("");
        this.title = this.titleSubject.asObservable();

        this.sessionSubject = new BehaviorSubject<string>("");
        this.session = this.sessionSubject.asObservable();
    }
    public nextBreadCrumb(val: string){
        this.titleSubject.next(val);
    }
    
    public get currentBreadCrumb(): string {
        return this.titleSubject.value;
    }

    public nextSession(val: string){
        this.sessionSubject.next(val);
    }
    
    public get currentSession(): string {
        return this.sessionSubject.value;
    }
}
