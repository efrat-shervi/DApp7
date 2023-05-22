import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.css']
})
export class ListUsersComponent  implements OnInit 
 {
  users:any;
   constructor(private http:HttpClient,private router: Router){}
     ngOnInit(): void {
      this.http.get('https://localhost:5001/api/users').subscribe({
  next: response => this.users = response,
  error: error => console.log(error),
  complete: () => console.log('request has completed')
});
  }
  
  goToAddUser() {
    // this.router.navigate(['/add-task']);
  }

  deleteUser(user:any){
    let index=this.users.indexOf(user);
    this.users.splice(index,1)
    this.http.delete('https://localhost:5001/api/users/' + user.id)
    .subscribe({
      next: response => console.log('User deleted successfully'),
      error: error => console.log('Error deleting assignment:', error),
      complete: () => console.log('Delete request completed')
    });
  }
}
