import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

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

  readonly youtubeUrl = 'https://www.youtube.com/embed/';
  readonly youtubeUrlParams = '?autoplayer=0';
  safeYTUrl: SafeResourceUrl;

  readonly twitchClipUrl = 'https://clips.twitch.tv/embed?clip=';
  readonly twitchClipParams = '&autoplay=false'
  safeTwitchUrl: SafeResourceUrl;

  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit() {
  }

  /**
   * Shows link embed based off of the given url
   * @param url URL object containing link to display 
   */
  public show(url: URL) {
    // Display depending on link type
    if(url.hostname === 'youtu.be' || url.hostname.includes('youtube.com')) {
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
    // Get video id, extract method depends on link type
    let videoId: string;
    if(url.hostname === 'youtu.be') {
      // Video id in path name, eg 'https://youtu.be/JMTlKJzoYS4'
      videoId = LinkEmbedComponent.getIdFromPath(url.pathname);
    }
    else { // Assuming should be youtube.com link
      // Video id is in query param, eg 'https://www.youtube.com/watch?v=JMTlKJzoYS4'
      videoId = LinkEmbedComponent.getIdFromPath(url.searchParams.get('v'), false, true);
    }
    console.log("YT video id:", videoId);
    if(!videoId) {
      this.showGeneral(url);
      return;
    }

    this.safeYTUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.youtubeUrl + videoId + this.youtubeUrlParams);
    this.linkType = LinkType.Youtube
  }

  private showTwitter(url: URL) {
    this.linkType = LinkType.Twitter;


  }

  private showTwitchClip(url: URL) {
    // Try to get the clip name
    let clipName = LinkEmbedComponent.getIdFromPath(url.pathname, true);
    if(!clipName) {
      this.showGeneral(url);
      return;
    }

    this.safeTwitchUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.twitchClipUrl + clipName + this.twitchClipParams);
    this.linkType = LinkType.TwitchClip;
  }

  private showGeneral(url: URL) {
    this.linkType = LinkType.General;

    // For now, just display the link generally
    this.displayLink = url.href;
  }

  /**
   * Extracts an id from the pathname or query param, or returns '' if none found. TODO: Redo naming and documentation
   * @param input
   * @param lettersOnly 
   * @param notFromPath
   * @returns Id from path (whatever's after the first / after removing any invalid characters), returns an empty string if couldn't find it
   */
  private static getIdFromPath(input: string, lettersOnly: boolean = false, notFromPath: boolean = false): string {
    let intermediate: string, id: string;

    if(!notFromPath) { // Need to extarct from path
      let splitPath = input.split('/');
      if(splitPath.length < 2) { // Expecting at least /Id
        return '';
      }
      intermediate = splitPath[1];
    }
    else { // No intermediate work necessary
      intermediate = input;
    }

    if(lettersOnly) {
      id = intermediate.replace(/[^a-zA-Z]+/g, '');
    }
    else {
      id = intermediate.replace(/[^\w-]+/g, ''); // Alphanumeric + underscore + dash (\w is a special case that does alphanumeric + underscore)
    }

    return id ? id : '';

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
