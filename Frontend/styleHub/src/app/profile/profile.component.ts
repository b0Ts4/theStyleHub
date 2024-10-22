import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  userData: any;

  constructor(private authService: AuthService) {}

  loadUserData() {
    this.userData = this.authService.getUserDataFromToken();
    console.log(this.userData);
  }

  ngOnInit() {
    this.loadUserData();
  }





}
