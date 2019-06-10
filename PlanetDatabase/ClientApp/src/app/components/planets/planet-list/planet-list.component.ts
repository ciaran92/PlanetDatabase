import { Component, OnInit } from '@angular/core';
import { Planet } from 'src/app/models/planet.model';
import { PlanetService } from 'src/app/shared/services/planet.service';

@Component({
  selector: 'home',
  templateUrl: './planet-list.component.html',
  styleUrls: ['./planet-list.component.css']
})
export class PlanetListComponent implements OnInit {

  planets: Planet[];
  
  constructor(private planetService: PlanetService) { }

  ngOnInit() {
    this.getAllPlanets();
  }

  getAllPlanets(){
    this.planetService.getAllPlanets().subscribe( res => {
      console.log(res);
      this.planets = res;
    });
  }

}
