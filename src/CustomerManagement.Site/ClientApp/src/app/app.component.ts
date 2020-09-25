import { Component, Pipe, PipeTransform, LOCALE_ID } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',  
})
export class AppComponent {
  title = 'app';
}

@Pipe({ 
  name: 'pipeFormatDate'
})
export class PipeFormatDate implements PipeTransform {
  
  transform(date: string): string {
    var datePipe = new DatePipe('pt');
    return datePipe.transform(this.format(date), 'dd/MM/yyyy');
  }

  format(value: any): string {
    if ((typeof value === 'string') && value.length == 8) {
      const day = value.substr(0,2);
      const month = value.substr(2,2);
      const year = value.substr(4,8);
      return (year+"/"+month+"/"+day);

    } else if ((typeof value === 'string') && (value.indexOf('/') > -1)) {
      return value.split('/').reverse().join('/');
    }
    return "";
  }
}
