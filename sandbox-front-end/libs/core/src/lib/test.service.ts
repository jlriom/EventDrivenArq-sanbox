import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class TestService {

  constructor(private http: HttpClient) { }

  test(apiBaseUrl): Observable<boolean> {
    return this.http.get<boolean>(`${apiBaseUrl}/document/test`);
  }
}
