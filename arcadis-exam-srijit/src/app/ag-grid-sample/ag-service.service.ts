import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable, of, Subject, throwError, BehaviorSubject } from 'rxjs';
import { map, catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { SampleModel } from './sample-model';
@Injectable({
  providedIn: 'root'
})
export class AgServiceService {
  myAppUrl : string;
  myApiUrl: string
  constructor(private http: HttpClient) { 
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = "api/Home"
  }

  addNewItem (model : SampleModel): Observable<any> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<any>(this.myAppUrl + this.myApiUrl + '/insertdata', model, { headers })
        .pipe(
            map(res => res),
            catchError(this.errorHandler)
        );
}
updateItem (model : SampleModel): Observable<any> {
  const headers = new HttpHeaders().set('content-type', 'application/json');
  return this.http.put<any>(this.myAppUrl + this.myApiUrl + '/updatedata', model, { headers })
      .pipe(
          map(res => res),
          catchError(this.errorHandler)
      );
}

deleteItem (id : number): Observable<any> {
  const headers = new HttpHeaders().set('content-type', 'application/json');
  return this.http.delete<any>(this.myAppUrl + this.myApiUrl + '/deletedata/'+id, { headers })
      .pipe(
          map(res => res),
          catchError(this.errorHandler)
      );
}
getallItem (): Observable<any> {
  return this.http.get<any>(this.myAppUrl + this.myApiUrl + '/get-all-data')
            .pipe(
                map(res => res),
                retry(1),
                catchError(this.errorHandler)
            );
}
getallSearchItem (searchString : string): Observable<any> {
  return this.http.get<any>(this.myAppUrl + this.myApiUrl + '/search/'+ searchString)
            .pipe(
                map(res => res),
                retry(1),
                catchError(this.errorHandler)
            );
}

errorHandler(error) {
  let errorMessage = '';
  if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
  } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
  }
  console.log(errorMessage);
  return throwError(errorMessage);
}

}
