import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

interface user {
  isSuccess: boolean;
  message: string;
  data: infor;
}
interface infor {
  id: number;
  userName: string;
  fullName: string;
  doB: string;
  email: string;
  phoneNumber: number;
  role: string;
  department: string;
}
interface create{
  userName: string;
  fullName: string;
  doB: string;
  email: string;
  phoneNumber: number;
  role: string;
  department: string;
}
@Injectable({
  providedIn: 'root',
})
export class UserService {
  private _api = 'https://localhost:7263/api';
  constructor(private http: HttpClient) {}

  public getUser(id: number) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhYjE4NmJkZC1iZmViLTRiNmItYmU3ZC1lOWFiM2UxYTNmNTkiLCJpYXQiOiI0LzcvMjAyMyA2OjA5OjEwIFBNIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJJZCI6IjIiLCJVc2VyTmFtZSI6IkFkbWluIiwiZXhwIjoxNjgwOTAxNzUwLCJpc3MiOiJDbGFzcy1UQ0gyMjAyLUlULUNPTVAxNjQwIiwiYXVkIjoiQ2xhc3MtVENIMjIwMi1JVC1DT01QMTY0MC1EdW5nZHQifQ.-tSVYmgeiwEtIhB0VgLgFIYBAiVEvbiVdq6NInf1DnY`,
    });
    const requestOptions = { headers: headers };
    return this.http.get<user>(this._api + `/Users/${id}`,requestOptions);
  }
  public getAllUser() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhYjE4NmJkZC1iZmViLTRiNmItYmU3ZC1lOWFiM2UxYTNmNTkiLCJpYXQiOiI0LzcvMjAyMyA2OjA5OjEwIFBNIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJJZCI6IjIiLCJVc2VyTmFtZSI6IkFkbWluIiwiZXhwIjoxNjgwOTAxNzUwLCJpc3MiOiJDbGFzcy1UQ0gyMjAyLUlULUNPTVAxNjQwIiwiYXVkIjoiQ2xhc3MtVENIMjIwMi1JVC1DT01QMTY0MC1EdW5nZHQifQ.-tSVYmgeiwEtIhB0VgLgFIYBAiVEvbiVdq6NInf1DnY`,
    });
    const requestOptions = { headers: headers };
    return this.http.get<infor[]>(this._api + `/Users`,requestOptions);
  }
  public deleteUser(id: number) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhYjE4NmJkZC1iZmViLTRiNmItYmU3ZC1lOWFiM2UxYTNmNTkiLCJpYXQiOiI0LzcvMjAyMyA2OjA5OjEwIFBNIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJJZCI6IjIiLCJVc2VyTmFtZSI6IkFkbWluIiwiZXhwIjoxNjgwOTAxNzUwLCJpc3MiOiJDbGFzcy1UQ0gyMjAyLUlULUNPTVAxNjQwIiwiYXVkIjoiQ2xhc3MtVENIMjIwMi1JVC1DT01QMTY0MC1EdW5nZHQifQ.-tSVYmgeiwEtIhB0VgLgFIYBAiVEvbiVdq6NInf1DnY`,
    });
    const requestOptions = { headers: headers };
    return this.http.delete<user>(this._api + `/Users/${id}`,requestOptions);
  }
  public createUser(data:create) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhYjE4NmJkZC1iZmViLTRiNmItYmU3ZC1lOWFiM2UxYTNmNTkiLCJpYXQiOiI0LzcvMjAyMyA2OjA5OjEwIFBNIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJJZCI6IjIiLCJVc2VyTmFtZSI6IkFkbWluIiwiZXhwIjoxNjgwOTAxNzUwLCJpc3MiOiJDbGFzcy1UQ0gyMjAyLUlULUNPTVAxNjQwIiwiYXVkIjoiQ2xhc3MtVENIMjIwMi1JVC1DT01QMTY0MC1EdW5nZHQifQ.-tSVYmgeiwEtIhB0VgLgFIYBAiVEvbiVdq6NInf1DnY`,
    });
    const requestOptions = { headers: headers };
    return this.http.post<user>(this._api + `/Users`,requestOptions);
  }
}
