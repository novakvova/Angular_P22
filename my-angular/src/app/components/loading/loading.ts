import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // для *ngIf
import { LoadingService } from '../../services/loading.service';

@Component({
  selector: 'app-loading',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './loading.html',
  styleUrls: ['./loading.css']
})
export class LoadingComponent {
  constructor(public loadingService: LoadingService) {}
}
