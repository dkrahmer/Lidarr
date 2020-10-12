import React, { Component } from 'react';
import PageContent from 'Components/Page/PageContent';
import PageContentBody from 'Components/Page/PageContentBody';
import AboutConnector from './About/AboutConnector';
import HealthConnector from './Health/HealthConnector';
import MoreInfo from './MoreInfo/MoreInfo';

class Status extends Component {

  //
  // Render

  render() {
    return (
      <PageContent title="Status">
        <PageContentBody>
          <HealthConnector />
          <AboutConnector />
          <MoreInfo />
        </PageContentBody>
      </PageContent>
    );
  }

}

export default Status;
