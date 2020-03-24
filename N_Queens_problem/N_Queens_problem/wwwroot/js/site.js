// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function selectAlgorithm() {

    if (document.getElementById('AlgorithmSelect').value == 'Hill Climbing') {
        document.getElementById('HillClimbingParameters').style.display = 'block';
        document.getElementById('SimulatedAnnealingParameters').style.display = 'none';
        document.getElementById('LocalBeamSearchParameters').style.display = 'none';
        document.getElementById('GeneticParameters').style.display = 'none';
    }
    else if (document.getElementById('AlgorithmSelect').value == 'Simulated Annealing') {
        document.getElementById('HillClimbingParameters').style.display = 'none';
        document.getElementById('SimulatedAnnealingParameters').style.display = 'block';
        document.getElementById('LocalBeamSearchParameters').style.display = 'none';
        document.getElementById('GeneticParameters').style.display = 'none';
    }
    else if (document.getElementById('AlgorithmSelect').value == 'Local Beam Search') {
        document.getElementById('HillClimbingParameters').style.display = 'none';
        document.getElementById('SimulatedAnnealingParameters').style.display = 'none';
        document.getElementById('LocalBeamSearchParameters').style.display = 'block';
        document.getElementById('GeneticParameters').style.display = 'none';
    }
    else if (document.getElementById('AlgorithmSelect').value == 'Genetic') {
        document.getElementById('HillClimbingParameters').style.display = 'none';
        document.getElementById('SimulatedAnnealingParameters').style.display = 'none';
        document.getElementById('LocalBeamSearchParameters').style.display = 'none';
        document.getElementById('GeneticParameters').style.display = 'block';
    }
}