<template>
    <div class="probablistic-approach">
        <div class="col-md-12">
            <div class="row">
                <b-form-group class="col-md-2">
                    <label for="group-number">p(C1)</label>
                    <b-form-input v-model="pc1" type="number" min="0.01" max="0.99" step="0.01"></b-form-input>
                </b-form-group>
                <b-form-group class="col-md-2">
                    <label for="group-number">p(C2)</label>
                    <b-form-input :value="pc2" type="number" readonly class="disabled"></b-form-input>
                </b-form-group>
                <b-form-group class="col-md-2">
                    <label for="group-number">Кол-во генерируемых точек</label>
                    <b-form-input v-model="countOfPoints" type="number"></b-form-input>
                </b-form-group>
                <b-form-group class="col-md-2">
                    <label for="group-number">Кол-во точек на графе</label>
                    <b-form-input v-model="countOfGraphPoints" type="number"></b-form-input>
                </b-form-group>
                <b-form-group class="col-md-2">
                    <label for="group-number">EPS</label>
                    <b-form-input v-model="eps" type="number"></b-form-input>
                </b-form-group>
            </div>
            <div class="row" v-if="falseProbability || skipProbability">
                <div class="col-md-12">Вероятность ложной тревоги {{falseProbability}}</div>
                <div class="col-md-12">Вероятность пропуска обнаружения {{skipProbability}}</div>
                <div class="col-md-12">Суммарная ошибка классификации {{falseProbability + skipProbability}}</div>
            </div>
        </div>
        <div class="col-md-12">
            <line-chart :chart-data="chartData"></line-chart>
        </div>
    </div>
</template>

<script>
import axios from "axios";
import LineChart from './LineChart.js'

export default {
  components: {
      LineChart
  },
  name: "ProbablisticApproach",
  data(){
    return {
        chartData: null,
        pc1: 0.35,
        countOfPoints: 10000,
        countOfGraphPoints: 1000,
        falseProbability: null,
        skipProbability: null,
        eps: 0.00001
    }
  },
  methods:{
    getData(){
        let baseMethodUrl = 'http://prm.local/api/ProbablisticApproach';
        let methodUrl = `${baseMethodUrl}?pc1=${this.pc1}&countOfPoints=${this.countOfPoints}&countOfGraphPoints=${this.countOfGraphPoints}&eps=${this.eps}`;

        axios.get(methodUrl)
        .then(response => {
            window.console.log(response);
            this.chartData = {
                labels: new Array(parseInt(this.countOfGraphPoints)),
                datasets:[
                    {
                        label: "p(x/C1) P(C1)",
                        data: response.data.FirstLine,
                        borderColor: '#ff6384'
                    },
                    {
                        label: "p(x/C2) P(C2)",
                        data: response.data.SecondLine,
                        borderColor: '#36a2eb'
                    }
                ]
            };
            this.falseProbability = response.data.FalseProbability;
            this.skipProbability = response.data.SkipProbability;
        })
        .catch(err => {
          window.console.warn(err);
        });
    }
  },
  created() {
    this.getData();
  },
  computed:{
      pc2: function (){
          return 1 - this.pc1;
      }
  },
  watch:{
      pc1: function(){
        this.getData();
      },
      countOfPoints: function(){
        this.getData();
      }, 
      countOfGraphPoints: function(){
        this.getData();
      },
      eps: function(){
          this.getData();
      }
  }
};
</script>