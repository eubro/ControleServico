import { Component } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { UserStoreService } from '../services/user-store.service';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent /*implements OnInit*/ {

  public users:any = [];
  public role!:string;

  public fullName : string = "";
  constructor(private api:ApiService,private auth: AuthenticationService, private userStore: UserStoreService) { }

  ngOnInit() {
    this.api.getUsers()
    .subscribe(res=>{
    this.users = res;
    });

    this.userStore.getFullNameFromStore()
    .subscribe(val=>{
      const fullNameFromToken = this.auth.getfullNameFromToken();
      this.fullName = val || fullNameFromToken
    });

    this.userStore.getRoleFromStore()
    .subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    })
  }

  logout(){
    this.auth.signOut();
  }

}
