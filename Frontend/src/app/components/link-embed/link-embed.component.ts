import { Component, OnInit } from '@angular/core';

export enum LinkType {
  Youtube,
  Twitter,
  TwitchClip,
  General
}

@Component({
  selector: 'link-embed',
  templateUrl: './link-embed.component.html',
  styleUrls: ['./link-embed.component.css']
})
export class LinkEmbedComponent implements OnInit {
  showEmbed: boolean;
  linkType: LinkType;
  
  displayLink: string; // For general display

  constructor() { }

  ngOnInit() {
  }

  /**
   * Shows link embed based off of the given url
   * @param url URL object containing link to display 
   */
  public show(url: URL) {
    // Display depending on link type
    if(url.hostname.includes('youtube.com')) {
      this.showYT(url);
    }
    else if(url.hostname.includes('twitter.com')) {
      this.showTwitter(url);
    }
    else if(url.hostname.includes('clips.twitch.tv')) {
      this.showTwitchClip(url);
    }
    else {
      this.showGeneral(url);
    }

    this.showEmbed = true;
  }

  /**
   * Hides the link embed
   */
  public hide() {
    this.showEmbed = false;
  }

  private showYT(url: URL) {
    this.linkType = LinkType.Youtube;


  }

  private showTwitter(url: URL) {
    this.linkType = LinkType.Twitter;


  }

  private showTwitchClip(url: URL) {
    // Try to get the clip name
    let fullPath = url.pathname.split('/');
    if(fullPath.length !== 2) { // Expecting only /ClipName 
      this.showGeneral(url);
      return;
    }
    console.log("Twitch path split:", fullPath);
    let clipName = fullPath[1];
    if(!clipName) {
      this.showGeneral(url);
      return;
    }


    this.displayLink = url.href;
    this.linkType = LinkType.TwitchClip;
  }

  private showGeneral(url: URL) {
    this.linkType = LinkType.General;

    // For now, just display the link generally
    this.displayLink = url.href;
  }

  // For clarity with template usage (currently believe it can't access the enum)
  isYTLink(): boolean {
    return this.linkType === LinkType.Youtube;
  }
  isTwitterLink(): boolean {
    return this.linkType === LinkType.Twitter;
  }
  isTwitchClipLink(): boolean {
    return this.linkType === LinkType.TwitchClip;
  }
  isGeneralLink(): boolean {
    return this.linkType === LinkType.General;
  }
}
