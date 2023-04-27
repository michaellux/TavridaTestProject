import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import { CompanyBranchesTable } from './components/CompanyBranchesTable';
import { Layout } from './components/Layout';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
        <Layout>
            <CompanyBranchesTable />
        </Layout>
    );
  }
}
