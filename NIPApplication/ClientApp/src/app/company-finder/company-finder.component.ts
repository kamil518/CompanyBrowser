import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-company-finder',
  templateUrl: './company-finder.component.html'
})
export class CompanyFinderComponent {
  public company: Company;
  public queryKey: string;
  public queried: boolean;
  public notFound: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.queried = false;
    this.notFound = false;
    this.queryKey = "";
  }

  public findCompany() {
    this.http.get<Company>(this.baseUrl + 'api/Companies?key=' + this.queryKey).subscribe(result => {

      if (result == null) {
        this.notFound = true;
        this.company = new Company();
      } else {
        this.company = result;
        this.notFound = false;
      }
      this.queried = true;
    }, error => console.log(error));
  }
}

class Company {
  name: string;
  street: string;
  streetNumber: string;
  postCode: string;
  city: string;
}
