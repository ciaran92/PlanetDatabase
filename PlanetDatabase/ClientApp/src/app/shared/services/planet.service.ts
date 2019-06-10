import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigService } from './config.service';
import { Observable } from 'rxjs';
import { Planet } from 'src/app/models/planet.model';

@Injectable()
export class PlanetService {

    private baseUrl: string;

    constructor(private http: HttpClient, private configService: ConfigService) { 
        this.baseUrl = configService.getApiURI();
    }

    getAllPlanets(): Observable<Planet[]> {
        return this.http.get<Planet[]>(this.baseUrl + '/planets', {
            headers: new HttpHeaders({
                "Content-Type": "application/json"
            })
        });
    }
}