import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import {CadServico} from '../models/CadServico';


@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  private url = 'CadServico'

  constructor(private http: HttpClient) { }

  public getServicos(): Observable<CadServico[]> {
    return this.http.get<CadServico[]>(`${environment.apiUrl}/${this.url}`);
  }
}
