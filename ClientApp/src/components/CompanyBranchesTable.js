import React, { Component } from 'react';

export class CompanyBranchesTable extends Component {
    static displayName = CompanyBranchesTable.name;

    constructor(props) {
        super(props);
        this.state = {
            companyBranches: [], loading: true,
        };
    }

    componentDidMount() {
        this.populateCompanyBranchesData();
    }

    static renderCompanyBranchesTable(companyBranches) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Company branch</th>
                        <th>Company</th>
                        <th>Group</th>
                        <th>Related Company branches</th>
                    </tr>
                </thead>
                <tbody>
                    {companyBranches.map(companyBranch =>
                        <tr key={companyBranch.name}>
                            <td>{companyBranch.name}</td>
                            <td>{companyBranch.company}</td>
                            <td>{companyBranch.group}</td>
                            <td>{companyBranch.relatedBranches}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CompanyBranchesTable.renderCompanyBranchesTable(this.state.companyBranches);

        return (
            <div>
                <h1 id="tableLabel">Company branches</h1>
                {contents}
            </div>
        );
    }

    async populateCompanyBranchesData() {
        const response = await fetch('companybranches');
        const data = await response.json();
        this.setState({ companyBranches: data, loading: false, });
    }
}