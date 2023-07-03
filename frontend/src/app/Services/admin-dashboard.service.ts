import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class AdminDashboardService {
  constructor(private httpClient: HttpClient) {}

  OnlineUsersCount(): Observable<number> {
    return this.httpClient.get<number>('/api/AdminDashboard/OnlineUsersCount');
  }

  // GetPartCount
  GetPartCount( size: number ): Observable<{ DocCount: number; Key: string }[]> 
  {    
      return this.httpClient.get<{ DocCount: number; Key: string }[]>(
        '/api/Part/GetPartCount?size=${size}'
      );
  }
}