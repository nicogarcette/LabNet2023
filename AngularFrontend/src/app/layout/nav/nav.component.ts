import { Component} from '@angular/core';
import {ChangeDetectorRef, OnInit} from '@angular/core';
import {MediaMatcher} from '@angular/cdk/layout'

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  fillerNav = [{name:'Inicio',router:'',icon:''},{name:'Empleados',router:'',icon:''}];
 ngOnInit(): void {
   
 }
}
