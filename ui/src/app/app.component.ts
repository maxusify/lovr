import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  public title: string = 'Lovr';
  public users: any;

  public constructor(private httpClient: HttpClient) {}

  public ngOnInit(): void {
    this.httpClient.get('https://localhost:5001/api/users').subscribe({
      next: (response) => (this.users = response),
      error: (error) => console.error(error),
      complete: () => {},
    });
  }
}
