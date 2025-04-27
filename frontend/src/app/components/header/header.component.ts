import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HostListener } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent {
  showAuthModal = false;

  toggleAuthModal(): void {
    this.showAuthModal = !this.showAuthModal;
  }

  closeAuthModal(): void {
    this.showAuthModal = false;
  }
}