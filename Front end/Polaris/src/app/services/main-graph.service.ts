import { EventEmitter, Injectable } from '@angular/core';
import * as Ogma from '../../assets/ogma.min.js';
import { NodeService } from './node/node.service';
import { GraphService } from './graph/graph.service';
@Injectable()
export class GraphHandlerService {
  public ogma: Ogma;
  public selectedNodes: Array<string>;
  public nodeColor: string;
  public edgeColor: string;
  public pathModel;
  public maxFlowModel;
  public graphChanged : EventEmitter<void> = new EventEmitter<void>();
  public graphStarted : boolean = false ;
  public pathsLoaded : EventEmitter<void> = new EventEmitter<void>();
  public flowLoaded : EventEmitter<void> = new EventEmitter<void>();
  constructor(
    public nodeService: NodeService,
    public graphService: GraphService
  ) { }

  public initOgma(configuration = {}) {
    this.ogma = new Ogma(configuration);
    this.selectedNodes = new Array<string>();
    this.ogma.styles.setSelectedNodeAttributes({outerStroke: function (node) {return node.isSelected() ? 'green' : null;}})
    this.ogma.styles.setSelectedEdgeAttributes({color: function (node) {return node.isSelected() ? 'green' : "gray"}})
    this.ogma.styles.addEdgeRule({
      text: {
        minVisibleSize: 4,
        size:14
      }
    });
  }
  public runLayout(): Promise<void> {
    this.graphChanged.emit();
    return this.ogma.layouts.force({ locate: true });
  }
  public getJsonGraph() {
    this.ogma.parse
      .jsonFromUrl('../../assets/data2.json')
      .then((graph) => this.setGraph(graph));
  }
  public setGraph(graph) {
    this.ogma.setGraph(graph);
    this.graphStarted = true ;
    this.runLayout();
  }

  public async getNodeByid(id: string): Promise<JSON> {
    let graphJson = await this.nodeService.getNode(id);
    this.graphStarted = true ;
    return graphJson;
  }

  public async addNode(id: string) {
    let nodeResult = await this.getNodeByid(id);
    if(nodeResult!=undefined)
       this.ogma.addNode(nodeResult);
    this.graphStarted = true ;
    this.runLayout();
  }

  public async getNodesByFilter(filter: string[]): Promise<JSON> {
    let graphJson = await this.nodeService.getNodes(filter);
    this.graphStarted = true ;
    return graphJson;
  }

  public async addNodes(filter: string[]) {
    let filterResults = await this.getNodesByFilter(filter);
    this.ogma.addNodes(filterResults);
    this.graphStarted = true ;
    this.runLayout();
  }

  public async expandOneNode(id: string) {
    let expandResult = await this.graphService.getExpansion(id);
    this.ogma.addGraph(expandResult);
    this.graphStarted = true ;
    this.runLayout();
  }

  public async expandNodes(ids: string[], nodeFilters: string[], edgeFilters: string[]) {
    let expansions = await this.graphService.getNodesExpansion(ids, nodeFilters, edgeFilters);
    this.ogma.addGraph(expansions);
    this.graphStarted = true ;
    this.runLayout();
  }

  public async getMaxFlow(sourceId: string,targetId: string,nodeFilters: string[],edgeFilters: string[]) {
    let flow = await this.graphService.getFlow(sourceId,targetId,nodeFilters,edgeFilters);
    this.maxFlowModel = JSON.parse(JSON.stringify(flow));
    this.ogma.addGraph(this.maxFlowModel.graphContainer);
    console.log("to use max flow number: " + this.maxFlowModel.maxFlowAmount);
    console.log("to use edges that has flow: " + this.maxFlowModel.edgeToFlow);
    this.flowLoaded.emit();
    this.graphStarted = true ;
    this.runLayout();
  }
  public async findPaths(sourceId: string, targetId: string, nodeFilters: string[], edgeFilters: string[], maxLength: number) {
    let paths = await this.graphService.getPaths(sourceId, targetId, nodeFilters, edgeFilters, maxLength);
    this.pathModel = JSON.parse(JSON.stringify(paths));
    this.ogma.addGraph(this.pathModel.graph);
    this.pathsLoaded.emit();
    this.graphStarted = true ;
    this.runLayout();
  }
  public removeNodes(ids: string[]) {
    this.graphStarted = true ;
    this.ogma.removeNodes(ids);
  }
  public setNodesAttributes(ids: string[]) {
    for (let node of ids) {
      this.ogma.getNode(node).setAttributes({ color: this.nodeColor });
    }
  }
  public setEdgesAttributes(ids: string[]) {
    for (let id of ids) {
      this.ogma.getEdge(id).setAttributes({ color: this.edgeColor });
    }
  }
}
